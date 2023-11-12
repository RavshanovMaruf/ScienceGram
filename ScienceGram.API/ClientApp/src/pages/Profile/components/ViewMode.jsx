import styles from "../style.module.scss";
import { useSelector } from "react-redux";

const ViewMode = () => {
	const user = useSelector((state) => state.user);

	return (
		<div className={styles.profile_inputs_wrapper}>
			<p className={styles.title}>Info</p>

			<div className={styles.info_wrapper}>
				<p className={styles.info_text}>First Name: </p>
				<p className={styles.info_text}>{user.firstName || "Unknown"}</p>
			</div>

			<div className={styles.info_wrapper}>
				<p className={styles.info_text}>Last Name: </p>
				<p className={styles.info_text}>{user.lastName || "Unknown"}</p>
			</div>

			<div className={styles.info_wrapper}>
				<p className={styles.info_text}>Email: </p>
				<p className={styles.info_text}>{user.email}</p>
			</div>

			<div className={styles.info_wrapper}>
				<p className={styles.info_text}>Phone: </p>
				<p className={styles.info_text}>{user.phone || "Unknown"}</p>
			</div>

			<div className={styles.info_wrapper}>
				<p className={styles.info_text}>Address: </p>
				<p className={styles.info_text}>{user.address || "Unknown"}</p>
			</div>

			<div className={styles.info_wrapper}>
				<p className={styles.info_text}>Fax: </p>
				<p className={styles.info_text}>{user.fax || "Unknown"}</p>
			</div>

			<div style={{ width: "100%" }}>
				<p className={styles.info_text}>Education</p>
				{user.educations.map((e) => (
					<div className={styles.education_wrapper}>
						<div className={styles.info_wrapper}>
							<p className={styles.info_text}>School: </p>
							<p className={styles.info_text}>{e.school || "Unknown"}</p>
						</div>
						<div className={styles.info_wrapper}>
							<p className={styles.info_text}>Grade: </p>
							<p className={styles.info_text}>{e.grade}</p>
						</div>
						<div className={styles.info_wrapper}>
							<p className={styles.info_text}>Start Year: </p>
							<p className={styles.info_text}>{e.startYear || "Unknown"}</p>
						</div>
						<div className={styles.info_wrapper}>
							<p className={styles.info_text}>End Year: </p>
							<p className={styles.info_text}>{e.endYear || "Unknown"}</p>
						</div>
					</div>
				))}
			</div>

			<div style={{ width: "100%" }}>
				<p className={styles.info_text}>Experiences</p>
				{user.experiences.map((e) => (
					<div className={styles.education_wrapper}>
						<div className={styles.info_wrapper}>
							<p className={styles.info_text}>Company Name: </p>
							<p className={styles.info_text}>{e.companyName || "Unknown"}</p>
						</div>
						<div className={styles.info_wrapper}>
							<p className={styles.info_text}>Position: </p>
							<p className={styles.info_text}>{e.position || "Unknown"}</p>
						</div>
					</div>
				))}
			</div>
		</div>
	);
};

export default ViewMode;
