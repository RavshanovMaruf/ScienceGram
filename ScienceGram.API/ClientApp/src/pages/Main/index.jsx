import { Button, TextField } from "@mui/material";
import styles from "./style.module.scss";
import Project from "../../components/Project";
import { getAllArxivProjects, getArxivProjects } from "../../services";
import { useEffect, useState } from "react";
import CreateProject from "../../components/CreateProject";
import { Link } from "react-router-dom";

const Main = () => {
	const handleOpen = () => setOpen(true);
	const [open, setOpen] = useState(false);
	const [search, setSearch] = useState("");
	const handleClose = () => setOpen(false);
	const [projects, setProjects] = useState(null);

	useEffect(() => {
		getAllArxivProjects().then((res) => setProjects(res?.data?.entries));
	}, []);

	const handleSearch = (e) => {
		e.preventDefault();
		getArxivProjects(search).then((res) => setProjects(res?.data?.entries));
	};

	return (
		<div>
			<CreateProject open={open} handleClose={handleClose} />

			<div className={styles.image_wrapper}>
				<h1 className={styles.heading}>
					Here you can find projects of other scientists.
				</h1>

				<Button
					variant="contained"
					onClick={handleOpen}
					className={styles.create_project_button}
					style={{
						padding: "12px 20px",
					}}
				>
					Create Project
				</Button>
			</div>

			<div className={styles.body}>
				<form className={styles.search_wrapper}>
					<TextField
						type="text"
						value={search}
						variant="outlined"
						className={styles.search}
						onChange={(e) => setSearch(e.target.value)}
						placeholder="Search for projects or articles..."
					/>
					<Button
						type="submit"
						variant="outlined"
						disabled={!search.replaceAll(" ", "")}
						onClick={handleSearch}
						onSubmit={handleSearch}
						style={{ padding: "10px 25px" }}
					>
						Search
					</Button>
				</form>

				<div className={styles.projects_wrapper}>
					{projects &&
						projects.map((e) => (
							<Link to="/app/project/about" key={e.id}>
								<Project data={e} key={e.id} />
							</Link>
						))}
				</div>
			</div>
		</div>
	);
};

export default Main;
