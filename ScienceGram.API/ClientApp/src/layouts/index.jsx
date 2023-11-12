import { Link, Outlet, useLocation, useNavigate } from "react-router-dom";
import Avatar from "@mui/material/Avatar";

import styles from "./style.module.scss";
import { Toaster } from "react-hot-toast";
import React, { useState } from "react";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import { useSelector } from "react-redux";

const Layout = () => {
	const navigate = useNavigate();
	const location = useLocation();
	const user = useSelector((state) => state.user);

	// ----------------------------------------------------------------------
	const [anchorEl, setAnchorEl] = useState(null);
	const open = Boolean(anchorEl);
	const handleClick = (event) => {
		setAnchorEl(event.currentTarget);
	};
	const handleClose = () => {
		setAnchorEl(null);
	};
	// ----------------------------------------------------------------------

	const logout = () => {
		localStorage.setItem("accessToken", "");
		navigate("/log-in");
	};

	return (
		<div className={styles.layout}>
			<Toaster position="top-right" />
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

				<div className={styles.navbar_profile_wrapper} onClick={handleClick}>
					<Avatar
						src="/broken-image.jpg"
						sx={{
							bgcolor:
								location.pathname === "/app/profile" ? "#007adf" : "gray",
						}}
					/>
					{user.firstName ? `${user.firstName} ${user.lastName}` : "Unknown"}
				</div>

				<Menu
					open={open}
					sx={{
						"&": {
							position: "absolute",
						},
						".MuiPaper-root": {
							marginTop: "5px",
							padding: "0 8px",
							width: "142px",
							borderRadius: "12px",
						},
					}}
					anchorEl={anchorEl}
					onClose={handleClose}
					anchorOrigin={{
						vertical: "bottom",
						horizontal: "right",
					}}
					transformOrigin={{
						vertical: "top",
						horizontal: "right",
					}}
				>
					<MenuItem onClick={handleClose}>
						<Link to="/app/profile" className={styles.menu_item}>
							Profile
						</Link>
					</MenuItem>
					<hr className={styles.horizontal_line} />
					<MenuItem onClick={logout} className={styles.menu_item}>
						Log out
					</MenuItem>
				</Menu>
			</nav>

			<div>
				<Outlet />
			</div>
		</div>
	);
};

export default Layout;
