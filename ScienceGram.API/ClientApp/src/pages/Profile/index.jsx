import { useState } from "react";
import EditMode from "./components/EditMode";
import ViewMode from "./components/ViewMode";
import styles from "./style.module.scss";
import EditRoundedIcon from "@mui/icons-material/EditRounded";
import { IconButton } from "@mui/material";

const Profile = () => {
	const [isEditMode, setIsEditMode] = useState(false);

	return (
		<div className={styles.profile_wrapper}>
			<div className={styles.profile_header_wrapper}>
				<h1 className={styles.profile_heading}>Profile</h1>

				<IconButton
					style={{ border: "1px solid lightslategray" }}
					onClick={() => setIsEditMode((prev) => !prev)}
				>
					<EditRoundedIcon />
				</IconButton>
			</div>

			{isEditMode ? <EditMode /> : <ViewMode />}
		</div>
	);
};

export default Profile;
