import backgroundImg from "../../assets/image5.jpg";
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
				<p className={styles.landing_desc}>
					Uniting Global Scholars for Collaboration, Conversation, and
					Collective Discovery!
				</p>
				<Link to="/log-in">
					<button className={styles.landing_button}>Log in</button>
				</Link>
			</div>
		</div>
	);
};

export default Landing;
