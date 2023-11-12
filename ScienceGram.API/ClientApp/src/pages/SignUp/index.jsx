import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import styles from "./style.module.scss";
import { Button, TextField } from "@mui/material";
import IconButton from "@mui/material/IconButton";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { signUp } from "../../services";

const SignUp = () => {
	const navigate = useNavigate();
	const [email, setEmail] = useState("");
	const [password, setPassword] = useState("");
	const [showPassword, setShowPassword] = useState(false);
	const [confirmPassword, setConfirmPassword] = useState("");
	const [showConfirmPassword, setShowConfirmPassword] = useState(false);

	const handleShowPassword = () => setShowPassword((show) => !show);
	const handleShowConfirmPassword = () =>
		setShowConfirmPassword((show) => !show);

	const handleChange = (type, input) => {
		const text = input.replaceAll(" ", "");
		if (type === "email") {
			setEmail(text);
		} else if (type === "password") {
			setPassword(text);
		} else {
			setConfirmPassword(text);
		}
	};

	const handleSignUp = (e) => {
		e.preventDefault();
		signUp({ email, password, confirmPassword }).then(() =>
			navigate("/log-in")
		);
	};

	return (
		<div className={styles.login_wrapper}>
			<div className={styles.login_block}>
				<div className={styles.block_header}>
					<p className={styles.block_title}>Sign Up</p>
				</div>

				<form className={styles.login_body_wrapper}>
					<TextField
						type="email"
						value={email}
						label="Email"
						variant="outlined"
						onChange={(e) => handleChange("email", e.target.value)}
					/>

					<div className={styles.password_field_wrapper}>
						<TextField
							value={password}
							label="Password"
							variant="outlined"
							style={{ width: "100%" }}
							autoComplete="new-password"
							type={showPassword ? "text" : "password"}
							onChange={(e) => handleChange("password", e.target.value)}
							sx={{
								".MuiInputBase-input": {
									paddingRight: "45px",
								},
							}}
						/>
						<div className={styles.eye_icon}>
							<IconButton onClick={handleShowPassword}>
								{showPassword ? <Visibility /> : <VisibilityOff />}
							</IconButton>
						</div>
					</div>

					<div className={styles.password_field_wrapper}>
						<TextField
							value={confirmPassword}
							label="Confirm Password"
							variant="outlined"
							style={{ width: "100%" }}
							autoComplete="new-password"
							type={showConfirmPassword ? "text" : "password"}
							onChange={(e) => handleChange("confirm-password", e.target.value)}
							sx={{
								".MuiInputBase-input": {
									paddingRight: "45px",
								},
							}}
						/>
						<div className={styles.eye_icon}>
							<IconButton onClick={handleShowConfirmPassword}>
								{showConfirmPassword ? <Visibility /> : <VisibilityOff />}
							</IconButton>
						</div>
					</div>

					<Button
						type="submit"
						variant="contained"
						disabled={
							!email.replaceAll(" ", "") ||
							!password.replaceAll(" ", "") ||
							!confirmPassword.replaceAll(" ", "")
						}
						onClick={handleSignUp}
						onSubmit={handleSignUp}
						style={{ borderRadius: "8px" }}
					>
						Sign Up
					</Button>
				</form>

				<p className={styles.sign_up_text}>
					Already have an account?{" "}
					<Link to="/log-in" className={styles.link}>
						Log In
					</Link>
				</p>
			</div>
		</div>
	);
};

export default SignUp;
