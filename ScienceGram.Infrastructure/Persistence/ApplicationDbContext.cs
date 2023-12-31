﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScienceGram.Core.Entities;
using ScienceGram.Infrastructure.Common;
using ScienceGram.Infrastructure.Interceptors;
using System.Reflection;

namespace ScienceGram.Infrastructure.Persistence
{
	public class ApplicationDbContext : IdentityDbContext<User, Role, int>
	{
		private readonly IMediator? _mediator;
		private readonly AuditableEntitySaveChangesInterceptor? _auditableEntitiesInterceptor;

		//public ApplicationDbContext() { }

		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options,
			AuditableEntitySaveChangesInterceptor auditableEntitiesInterceptor,
			IMediator mediator
		)
			: base(options)
		{
			_auditableEntitiesInterceptor = auditableEntitiesInterceptor;
			_mediator = mediator;
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public virtual DbSet<Collaboration> Collaborations => Set<Collaboration>();
		public virtual DbSet<Project> Projects => Set<Project>();
		public virtual DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();
		public virtual DbSet<ProjectSkill> ProjectSkills => Set<ProjectSkill>();
		public virtual DbSet<ProjectLanguage> ProjectLanguages => Set<ProjectLanguage>();
		public virtual DbSet<Experience> Experiences => Set<Experience>();

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>()
				.Ignore(u => u.AccessFailedCount)
				.Ignore(u => u.LockoutEnabled)
				.Ignore(u => u.LockoutEnd)
				.Ignore(u => u.TwoFactorEnabled)
				.Ignore(u => u.PhoneNumberConfirmed);

			builder.Entity<User>().ToTable("Users");
			builder.Entity<Role>().ToTable("Roles");
			builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
			builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
			builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
			builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
			builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.AddInterceptors(_auditableEntitiesInterceptor);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			await _mediator.DispatchDomainEvents(this);

			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
