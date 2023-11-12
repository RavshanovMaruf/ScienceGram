using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ScienceGram.Application.Common.DTOs;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;

namespace ScienceGram.Application.Features.Projects.Commands.Create
{
	public class CreateProjectCommand : IRequest<CreatedProjectResponse>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Field { get; set; }
		public IList<string> ProjectSkillNames { get; set; }
		public IList<string> ProjectLanguages { get; set; }
	}

	public class CreateProjectCommandHandler
		: IRequestHandler<CreateProjectCommand, CreatedProjectResponse>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;
		private readonly ICurrentUserService _currentUserService;
		private readonly UserManager<User> _userManager;
		private readonly IProjectSkillRepository _projectSkillRepository;
		private readonly IProjectLanguageRepository _projectLanguageRepository;

		public CreateProjectCommandHandler(
			IProjectRepository projectRepository,
			IMapper mapper,
			ICurrentUserService currentUserService,
			UserManager<User> userManager,
			IProjectSkillRepository projectSkillRepository,
			IProjectLanguageRepository projectLanguageRepository
		)
		{
			_projectRepository = projectRepository;
			_mapper = mapper;
			_currentUserService = currentUserService;
			_userManager = userManager;
			_projectSkillRepository = projectSkillRepository;
			_projectLanguageRepository = projectLanguageRepository;
		}

		public async Task<CreatedProjectResponse> Handle(
			CreateProjectCommand request,
			CancellationToken cancellationToken
		)
		{
			var user = await _userManager.FindByEmailAsync(_currentUserService.UserEmail!);

			var project = new Project
			{
				Title = request.Title,
				Description = request.Description,
				Field = request.Field,
				LeadScientistId = user!.Id,
			};

			var createdProject = await _projectRepository.AddAsync(project);

			var createdProjectSkills = new List<ProjectSkillDto>();
			var createdProjectLanguages = new List<ProjectLanguageDto>();

			if (request.ProjectSkillNames != null)
			{
				foreach (var projectSkillName in request.ProjectSkillNames)
				{
					var projectSkill = new ProjectSkill
					{
						ProjectId = createdProject.Id,
						SkillName = projectSkillName,
					};

					var createdProjectSkill = await _projectSkillRepository.AddAsync(projectSkill);
					createdProjectSkills.Add(_mapper.Map<ProjectSkillDto>(createdProjectSkill));
				}
			}

			if (request.ProjectLanguages != null)
			{
				foreach (var projectLanguage in request.ProjectLanguages)
				{
					var projectLanguageEntity = new ProjectLanguage
					{
						ProjectId = createdProject.Id,
						Language = projectLanguage,
					};

					var createdProjectLanguage = await _projectLanguageRepository.AddAsync(projectLanguageEntity);
					createdProjectLanguages.Add(_mapper.Map<ProjectLanguageDto>(createdProjectLanguage));
				}
			}

			var mappedProject = _mapper.Map<CreatedProjectResponse>(createdProject);

			mappedProject.ProjectSkillNames = createdProjectSkills;
			mappedProject.ProjectLanguages = createdProjectLanguages;

			return mappedProject;
		}
	}
}
