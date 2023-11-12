import { useState } from "react";
import styles from "../style.module.scss";
import { TextField } from "@mui/material";

const Experience = ({ data }) => {
	const [position, setPosition] = useState(data.position);
	const [companyName, setCompanyName] = useState(data.companyName);

	return (
		<div className={styles.experience_inputs_wrapper}>
			<TextField
				type="text"
				value={position}
				label="Position"
				variant="outlined"
				className={styles.profile_input}
				onChange={(e) => setPosition(e.target.value)}
			/>

			<TextField
				type="email"
				variant="outlined"
				value={companyName}
				label="Company Name"
				className={styles.profile_input}
				onChange={(e) => setCompanyName(e.target.value)}
			/>
		</div>
	);
};

export default Experience;
