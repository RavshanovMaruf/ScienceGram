import { useNavigate, useParams } from "react-router";
import image from "../../assets/image3.jpg";
import styles from "./style.module.scss";
import About from "./About";

const ProjectPage = () => {
	const { nav } = useParams();
	const navigate = useNavigate();

	return (
		<div>
			<div className={styles.image_wrapper}>
				<img className={styles.image} src={image} alt="photo1" />
			</div>

			<div className={styles.body_wrapper}>
				<div className={styles.tab_bar}>
					<button
						onClick={() => navigate("/app/project/about")}
						className={`${styles.tab_button} ${
							nav === "about" && styles.active
						}`}
					>
						About
					</button>
					<a href="https://localhost:44354/">
						<button
							className={`${styles.tab_button} ${
								nav === "chat" && styles.active
							}`}
						>
							Chat
						</button>
					</a>
				</div>
				{nav === "about" && <About />}
			</div>
		</div>
	);
};

export default ProjectPage;
