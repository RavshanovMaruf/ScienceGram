import styles from "./style.module.scss";

const Project = ({ data }) => {
	return (
		<div className={styles.project_wrapper}>
			<h1 className={styles.project_title}>{data?.title}</h1>
			<p className={styles.project_summary}>{data?.summary}</p>

			<div className={styles.authors_wrapper}>
				<p className={styles.subtitle}>Authors:</p>
				{data?.authors?.map((e) => (
					<p className={styles.project_author}>{e?.name},</p>
				))}
			</div>

			{data?.journalRef && (
				<div className={styles.authors_wrapper}>
					<p className={styles.subtitle}>Journal Ref:</p>
					<p className={styles.project_journal}>{data?.journalRef}</p>
				</div>
			)}
		</div>
	);
};

export default Project;
