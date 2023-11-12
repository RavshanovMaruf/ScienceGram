import { Button, IconButton, TextField } from "@mui/material";
import Modal from "@mui/material/Modal";
import styles from "./style.module.scss";
import CloseRoundedIcon from "@mui/icons-material/CloseRounded";
import { useState } from "react";

const CreateProject = ({ open, handleClose }) => {
	const [title, setTitle] = useState("");
	const [field, setField] = useState("");
	const [skills, setSkills] = useState("");
	const [languages, setLanguages] = useState("");
	const [description, setDescription] = useState("");

	return (
		<Modal open={open} onClose={handleClose}>
			<div className={styles.modal_wrapper}>
				<div className={styles.modal_header}>
					<p className={styles.modal_heading}>Create a Project</p>

					<IconButton onClick={handleClose}>
						<CloseRoundedIcon />
					</IconButton>
				</div>

				<div className={styles.modal_body}>
					<TextField
						type="text"
						label="Title"
						value={title}
						variant="outlined"
						className={styles.search}
						onChange={(e) => setTitle(e.target.value)}
						placeholder="Research on quantum physics..."
					/>

					<textarea
						value={description}
						placeholder="Description"
						className={styles.description_textarea}
						onChange={(e) => setDescription(e.target.value)}
					/>

					<TextField
						type="text"
						variant="outlined"
						value={field}
						className={styles.search}
						label="Field/Area of research"
						placeholder="Physics, Chemistry..."
						onChange={(e) => setField(e.target.value)}
					/>

					<TextField
						type="text"
						value={skills}
						variant="outlined"
						label="Desired skills"
						className={styles.search}
						placeholder="Math, Biology..."
						onChange={(e) => setSkills(e.target.value)}
					/>

					<TextField
						type="text"
						value={languages}
						label="Languages"
						variant="outlined"
						className={styles.search}
						placeholder="English, Spanish..."
						onChange={(e) => setLanguages(e.target.value)}
					/>

					<Button
						variant="contained"
						style={{ width: "fit-content", margin: "0 auto" }}
						disabled={
							!title.replaceAll(" ", "") ||
							!field.replaceAll(" ", "") ||
							!skills.replaceAll(" ", "") ||
							!languages.replaceAll(" ", "") ||
							!description.replaceAll(" ", "")
						}
					>
						Create
					</Button>
				</div>
			</div>
		</Modal>
	);
};

export default CreateProject;
