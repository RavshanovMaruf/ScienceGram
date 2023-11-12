import backgroundImg from "../../assets/image5.jpg";
import landingImg from "../../assets/image4.png";
import styles from "./style.module.scss";
import { Link } from "react-router-dom";

const Landing = () => {
	return (
		<div
			className={styles.landing_wrapper}
			style={{ backgroundImage: `url(${backgroundImg})` }}
		>
			<div className={styles.landing_text_wrapper}>
				<h1 className={styles.landing_heading}>
					Science<span className={styles.hub}>Hub</span>
				</h1>
				<p1 className={styles.landing_desc}>This is our description.</p1>
				<Link to="/log-in">
					<button className={styles.landing_button}>Log in</button>
				</Link>
			</div>

			<div
				className={styles.landing_image_wrapper}
				style={{ backgroundImage: `url(${landingImg})` }}
			></div>
		</div>
	);
};

export default Landing;
