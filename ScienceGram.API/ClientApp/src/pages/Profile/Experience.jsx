import { useState } from "react";
import styles from "./style.module.scss";
import { TextField } from "@mui/material";

const Experience = () => {
	const [email, setEmail] = useState("");
	const [lastName, setLastName] = useState("");

	const handleChange = (type, input) => {
		const text = input.replaceAll(" ", "");
		if (type === "email") {
			setEmail(text);
		}
	};

	return (
		<div className={styles.experience_inputs_wrapper}>
			<TextField
				type="text"
				value={lastName}
				label="Position"
				variant="outlined"
				className={styles.profile_input}
				onChange={(e) => setLastName(e.target.value)}
			/>

			<TextField
				type="email"
				value={email}
				label="Company Name"
				variant="outlined"
				className={styles.profile_input}
				onChange={(e) => handleChange("email", e.target.value)}
			/>
		</div>
	);
};

export default Experience;
