import { Link, Outlet, useLocation } from "react-router-dom";
import Avatar from "@mui/material/Avatar";

import styles from "./style.module.scss";

const Layout = () => {
	const location = useLocation();
	return (
		<div className={styles.layout}>
			<nav className={styles.navbar}>
				<Link to="/app/main">
					<h1 className={styles.logo}>
						Science<span className={styles.hub}>Hub</span>
					</h1>
				</Link>

				<Link to={"/app/main"} className={styles.navbar_link}>
					<button
						className={`${styles.navbar_button} ${
							location.pathname === "/app/main" && styles.active
						}`}
					>
						Main
					</button>
				</Link>

				<div className={styles.navbar_profile_wrapper}>
					<Link to="/app/profile">
						<Avatar
							src="/broken-image.jpg"
							sx={{
								bgcolor:
									location.pathname === "/app/profile" ? "#007adf" : "gray",
							}}
						/>
					</Link>
					<Link to="/app/profile" className={styles.profile_link}>
						Profile
					</Link>
				</div>
			</nav>

			<div>
				<Outlet />
			</div>
		</div>
	);
};

export default Layout;
