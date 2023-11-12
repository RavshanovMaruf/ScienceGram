import { useState } from "react";
import Education from "./Education";
import Experience from "./Experience";
import { Button, TextField } from "@mui/material";
import AddRoundedIcon from "@mui/icons-material/AddRounded";
import styles from "../style.module.scss";
import { useDispatch, useSelector } from "react-redux";
import { updateUserAction } from "../../../store/userReducer";

const EditMode = () => {
	const dispatch = useDispatch();
	const user = useSelector((state) => state.user);
	const [fax, setFax] = useState(user.fax);
	const [email, setEmail] = useState(user.email);
	const [phone, setPhone] = useState(user.phone);
	const [address, setAddress] = useState(user.address);
	const [lastName, setLastName] = useState(user.lastName);
	const [firstName, setFirstName] = useState(user.firstName);

	const handleChange = (type, input) => {
		const text = input.replaceAll(" ", "");
		if (type === "email") {
			setEmail(text);
		}
	};

	const handleAddEducation = () => {
		dispatch(
			updateUserAction({
				...user,
				educations: [
					...user.educations,
					{
						grade: 0,
						endYear: 0,
						school: "",
						degree: "",
						startYear: 0,
					},
				],
			})
		);
	};

	const handleAddExperience = () => {
		dispatch(
			updateUserAction({
				...user,
				experiences: [
					...user.experiences,
					{
						position: "",
						companyName: "",
					},
				],
			})
		);
	};

	const handleSave = () => {
		dispatch(
			updateUserAction({
				...user,
				fax,
				email,
				phone,
				address,
				lastName,
				firstName,
			})
		);
	};

	return (
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
					value={phone}
					label="Phone"
					variant="outlined"
					className={styles.profile_input}
					onChange={(e) => setPhone(e.target.value)}
				/>
			</div>

			<div className={styles.inputs_wrapper}>
				<TextField
					type="text"
					value={address}
					label="Address"
					variant="outlined"
					className={styles.profile_input}
					onChange={(e) => setAddress(e.target.value)}
				/>

				<TextField
					type="text"
					value={fax}
					label="Fax"
					variant="outlined"
					className={styles.profile_input}
					onChange={(e) => setFax(e.target.value)}
				/>
			</div>

			<p className={styles.title}>Education</p>

			{user?.educations?.map((e, i) => (
				<Education key={i} data={e} />
			))}

			<button className={styles.add_button} onClick={handleAddEducation}>
				<AddRoundedIcon /> Add Education
			</button>

			<p className={styles.title}>Experience</p>

			{user?.experiences?.map((e, i) => (
				<Experience key={i} data={e} />
			))}

			<button className={styles.add_button} onClick={handleAddExperience}>
				<AddRoundedIcon /> Add Experience
			</button>

			<div className={styles.save_button_wrapper}>
				<Button variant="contained" onClick={handleSave}>
					Save
				</Button>
			</div>
		</div>
	);
};

export default EditMode;
