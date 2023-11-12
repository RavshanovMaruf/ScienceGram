import { Button, TextField } from "@mui/material";
import styles from "./style.module.scss";
import Project from "../../components/Project";
import { useEffect } from "react";

const Main = () => {
	useEffect(() => {
		fetch("https://localhost:7176/api/arxiv/arxiv-projects?searchQuery=arthur")
			.then((res) => res.json())
			.then((data) => console.log("DATA", data));
	}, []);
	return (
		<div>
			<div className={styles.image_wrapper}>
				<h1 className={styles.heading}>
					Here you can find projects of other scientists.
				</h1>

				<Button className={styles.create_project_button} variant="contained">
					Create Project
				</Button>
			</div>

			<div className={styles.body}>
				<div className={styles.search_wrapper}>
					<TextField
						type="email"
						variant="outlined"
						placeholder="Email"
						className={styles.search}
					/>
				</div>

				<div className={styles.projects_wrapper}>
					<Project />
				</div>
			</div>
		</div>
	);
};

export default Main;
