import { useState } from "react";
import styles from "./style.module.scss";
import { TextField } from "@mui/material";
import AddRoundedIcon from "@mui/icons-material/AddRounded";
import Education from "./Education";
import Experience from "./Experience";

const Profile = () => {
	const [email, setEmail] = useState("");
	const [lastName, setLastName] = useState("");
	const [firstName, setFirstName] = useState("");
	const [educations, setEducations] = useState([<Education />]);
	const [experiences, setExperiences] = useState([<Experience />]);

	const handleChange = (type, input) => {
		const text = input.replaceAll(" ", "");
		if (type === "email") {
			setEmail(text);
		}
	};

	const handleAddEducation = () => {
		setEducations((prev) => [...prev, <Education />]);
	};

	const handleAddExperience = () => {
		setExperiences((prev) => [...prev, <Experience />]);
	};

	return (
		<div className={styles.profile_wrapper}>
			<h1 className={styles.profile_heading}>Profile</h1>

			<div className={styles.profile_inputs_wrapper}>
				<p className={styles.title}>Info</p>

				<div className={styles.inputs_wrapper}>
					<TextField
						type="text"
						value={firstName}
						label="First Name"
						variant="outlined"
						className={styles.profile_input}
						onChange={(e) => setFirstName(e.target.value)}
					/>

					<TextField
						type="text"
						value={lastName}
						label="Last Name"
						variant="outlined"
						className={styles.profile_input}
						onChange={(e) => setLastName(e.target.value)}
					/>
				</div>

				<div className={styles.inputs_wrapper}>
					<TextField
						type="email"
						value={email}
						label="Email"
						variant="outlined"
						className={styles.profile_input}
						onChange={(e) => handleChange("email", e.target.value)}
					/>
					<TextField
						type="text"
						value={firstName}
						label="Phone"
						variant="outlined"
						className={styles.profile_input}
						onChange={(e) => setFirstName(e.target.value)}
					/>
				</div>

				<div className={styles.inputs_wrapper}>
					<TextField
						type="text"
						value={lastName}
						label="Address"
						variant="outlined"
						className={styles.profile_input}
						onChange={(e) => setLastName(e.target.value)}
					/>

					<TextField
						type="email"
						value={email}
						label="Fax"
						variant="outlined"
						className={styles.profile_input}
						onChange={(e) => handleChange("email", e.target.value)}
					/>
				</div>

				<p className={styles.title}>Education</p>

				{educations}

				<button className={styles.add_button} onClick={handleAddEducation}>
					<AddRoundedIcon /> Add Education
				</button>

				<p className={styles.title}>Experience</p>

				{experiences}

				<button className={styles.add_button} onClick={handleAddExperience}>
					<AddRoundedIcon /> Add Experience
				</button>
			</div>
		</div>
	);
};

export default Profile;
