import { useState } from "react";
import styles from "../style.module.scss";
import { TextField } from "@mui/material";

const Education = ({ data }) => {
	const [field, setField] = useState(data.field);
	const [grade, setGrade] = useState(data.grade);
	const [school, setSchool] = useState(data.school);
	const [degree, setDegree] = useState(data.degree);
	const [endYear, setEndYear] = useState(data.endYear);
	const [startYear, setStartYear] = useState(data.startYear);

	return (
		<div className={styles.education_inputs_wrapper}>
			<div className={styles.inputs_wrapper}>
				<TextField
					type="text"
					value={school}
					label="School"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => setSchool(e.target.value)}
				/>

				<TextField
					type="text"
					value={degree}
					label="Degree"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => setDegree(e.target.value)}
				/>
			</div>

			<div className={styles.inputs_wrapper}>
				<TextField
					type="text"
					value={field}
					variant="outlined"
					label="Field of Study"
					className={styles.education_input}
					onChange={(e) => setField(e.target.value)}
				/>
				<TextField
					type="text"
					value={grade}
					label="Grade"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => setGrade(e.target.value)}
				/>
			</div>

			<div className={styles.inputs_wrapper}>
				<TextField
					type="number"
					value={startYear}
					label="Start Year"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => setStartYear(e.target.value)}
				/>

				<TextField
					type="number"
					value={endYear}
					label="End Year"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => setEndYear(e.target.value)}
				/>
			</div>
		</div>
	);
};

export default Education;
