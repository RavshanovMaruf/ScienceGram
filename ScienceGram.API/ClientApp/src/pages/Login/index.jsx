import { Button, TextField } from "@mui/material";
import styles from "./style.module.scss";
import { useState } from "react";
import { Link } from "react-router-dom";
import IconButton from "@mui/material/IconButton";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";

const Login = () => {
	const [email, setEmail] = useState("");
	const [password, setPassword] = useState("");
	const [showPassword, setShowPassword] = useState(false);

	const handleClickShowPassword = () => setShowPassword((show) => !show);

	const handleMouseDownPassword = (event) => {
		event.preventDefault();
	};

	const handleChange = (isPassword, input) => {
		const text = input.replaceAll(" ", "");
		if (isPassword) {
			setPassword(text);
		} else {
			setEmail(text);
		}
	};

	return (
		<div className={styles.login_wrapper}>
			<div className={styles.login_block}>
				<div className={styles.block_header}>
					<p className={styles.block_title}>Log In</p>
				</div>

				<form className={styles.login_body_wrapper}>
					<TextField
						type="email"
						value={email}
						label="Email"
						variant="outlined"
						onChange={(e) => handleChange(false, e.target.value)}
					/>

					<div className={styles.password_field_wrapper}>
						<TextField
							value={password}
							label="Password"
							variant="outlined"
							style={{ width: "100%" }}
							autoComplete="new-password"
							type={showPassword ? "text" : "password"}
							onChange={(e) => handleChange(true, e.target.value)}
							sx={{
								".MuiInputBase-input": {
									paddingRight: "45px",
								},
							}}
						/>
						<div className={styles.eye_icon}>
							<IconButton
								onClick={handleClickShowPassword}
								onMouseDown={handleMouseDownPassword}
							>
								{showPassword ? <VisibilityOff /> : <Visibility />}
							</IconButton>
						</div>
					</div>

					<Button
						style={{ borderRadius: "8px" }}
						variant="contained"
						type="submit"
					>
						Log In
					</Button>
				</form>

				<p className={styles.sign_up_text}>
					Don't have an accout?{" "}
					<Link to="/sign-up" className={styles.link}>
						Sign Up
					</Link>
				</p>
			</div>
		</div>
	);
};

export default Login;
