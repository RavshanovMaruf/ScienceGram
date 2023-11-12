import Layout from "./layouts";
import Login from "./pages/Login";
import SignUp from "./pages/SignUp";
import Landing from "./pages/Landing";
import Profile from "./pages/Profile";
import { Routes, Route } from "react-router-dom";
import Main from "./pages/Main";

const App = () => {
	return (
		<div>
			<Routes>
				<Route path="/" element={<Landing />} />
				<Route path="/log-in" element={<Login />} />
				<Route path="/sign-up" element={<SignUp />} />
				<Route path="/app" element={<Layout />}>
					<Route path="/app/main" element={<Main />} />
					<Route path="/app/profile" element={<Profile />} />
				</Route>
			</Routes>
		</div>
	);
};

export default App;
