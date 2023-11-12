import { useState } from "react";
import styles from "./style.module.scss";
import { TextField } from "@mui/material";

const Education = () => {
	const [email, setEmail] = useState("");
	const [lastName, setLastName] = useState("");

	const handleChange = (type, input) => {
		const text = input.replaceAll(" ", "");
		if (type === "email") {
			setEmail(text);
		}
	};

	return (
		<div className={styles.education_inputs_wrapper}>
			<div className={styles.inputs_wrapper}>
				<TextField
					type="text"
					value={lastName}
					label="School"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => setLastName(e.target.value)}
				/>

				<TextField
					type="email"
					value={email}
					label="Degree"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => handleChange("email", e.target.value)}
				/>
			</div>

			<div className={styles.inputs_wrapper}>
				<TextField
					type="email"
					value={email}
					label="Start Year"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => handleChange("email", e.target.value)}
				/>

				<TextField
					type="email"
					value={email}
					label="End Year"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => handleChange("email", e.target.value)}
				/>
			</div>

			<div className={styles.inputs_wrapper}>
				<TextField
					type="email"
					value={email}
					label="Grade"
					variant="outlined"
					className={styles.education_input}
					onChange={(e) => handleChange("email", e.target.value)}
				/>

				<div className={styles.education_input}></div>
			</div>
		</div>
	);
};

export default Education;
