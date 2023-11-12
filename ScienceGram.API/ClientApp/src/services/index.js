import axios from "axios";
import toast from "react-hot-toast";

export const authClient = axios.create({
	baseURL: "https://localhost:7176/api",
});

export const client = axios.create({
	baseURL: "https://localhost:7176/api",
});

client.interceptors.request.use(
	(config) => {
		const access_token = localStorage.getItem("accessToken");

		if (access_token) {
			config.headers.Authorization = `Bearer ${access_token}`;
		}
		return config;
	},
	(error) => {
		return Promise.reject(error);
	}
);

// ----------------------- AUTH API -----------------------

export const signUp = (data) =>
	authClient.post("/account/sign-up", data).catch(() =>
		toast.error("Something bad happened\nPlease try again later.", {
			id: "sign-up",
		})
	);

export const signIn = (data) =>
	authClient.post("/account/sign-in", data).catch(() =>
		toast.error("Something bad happened\nPlease try again later.", {
			id: "sign-in",
		})
	);

// ----------------------- PROJECTS API -----------------------

export const getArxivProjects = (searchQuery) =>
	client.get("/arxiv/arxiv-projects", { params: { searchQuery } }).catch(() =>
		toast.error("Something bad happened\nPlease try again later.", {
			id: "arxiv-projects",
		})
	);
