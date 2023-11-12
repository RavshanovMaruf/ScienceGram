const UPDATE_USER = "UPDATE_USER";

const defaultState = {
	id: "",
	fax: "+ 49 (0) 241 80 628 498",
	phone: "+ 49 (0) 241 80 99 138",
	email: "user@example.com",
	avatar: "",
	address: "Schinkelstr. 2 D-52062 Aachen Germany",
	lastName: "Rashidov",
	firstName: "Khasan",
	educations: [
		{
			grade: 4,
			endYear: 2024,
			school: "IUT",
			degree: "BSC",
			startYear: 2020,
		},
	],
	experiences: [
		{
			position: "Software Engineer",
			companyName: "Vention Group",
		},
	],
};

export function user(state = defaultState, action) {
	const data = action.payload;

	switch (action.type) {
		case UPDATE_USER:
			return { ...data };
		default:
			return state;
	}
}

export const updateUserAction = (payload) => ({
	type: UPDATE_USER,
	payload,
});
