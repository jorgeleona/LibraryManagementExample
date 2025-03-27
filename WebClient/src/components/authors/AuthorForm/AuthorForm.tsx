import React, { useState } from "react";
import style from "./AuthorForm.module.css";
import Author from "services/author/Author";

const authUrl = "http://localhost:5172/auth/auth-token";
const saveAuthUrl = "http://localhost:5172/api/authors";

const apiKey =
	"XmpV6v6G0YCc05dasg5XJKf8HL6k6BcteiFa6gh4HGckgBw01IiC3OPPNpl9myjlftk8gQ3rCB69MAoZ47h3KdLjMIeEumCcynKqyp48CtHkcVNQmMfqLd7s9795qnLccbrVNj7snPPipNQbZaQVwDYtkd2sBQ8UqrNxXfyem1wQtpIdYVqvVIzfrcrvDE73bcYNcdy3rDtLYvRQrnPdfeut3Z8lgFwc4MCGgZORVsOWCQfArszpQe5qfdSOWUAe";
const creds = { User: "xuser", Password: "#$$u53r??" };

const defaultAuthor: Author = {
	Name: "",
	DateOfBirth: ""
};

const AuthorForm = () => {
	const [authorData, setAuthorData] = useState<Author>(defaultAuthor);

	const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		const { id, value } = event.target;
		setAuthorData((prev) => ({ ...prev, [id]: value }));
	};

	const handleOnSubmit = async (event: React.FormEvent) => {
		event.preventDefault();
		console.log("to send  :", authorData);

		const authResponse = await fetch(authUrl, {
			mode: "cors",
			method: "POST",
			headers: {
				"Access-Control-Allow-Origin": "http://localhost:5173",
				"Access-Control-Allow-Credentials": "true",
				"Content-Type": "application/json",
				Accept: "application/json",
				"x-api-key": apiKey
			},
			body: JSON.stringify(creds)
		});
		if (authResponse.ok) {
			const token = await authResponse.text();
			const payload = JSON.stringify(authorData);

			const saveResponse = await fetch(saveAuthUrl, {
				mode: "cors",
				method: "POST",
				headers: {
					"Access-Control-Allow-Origin": "http://localhost:5173",
					"Access-Control-Allow-Credentials": "true",
					"Content-Type": "application/json",
					Accept: "application/json",
					"x-api-key": apiKey,
					Authorization:
						"Bearer " + token.replace(/[\n\r]/g, "").replace(/"/g, "")
				},
				body: payload
			});

			if (saveResponse.ok) {
				console.log("author saved");
				setAuthorData(defaultAuthor);
			}
		} else {
			console.log("auth failed");
		}
	};

	const handleCancel = () => {
		setAuthorData(defaultAuthor);
	};

	return (
		<div className={style.container}>
			<h2>Add Author</h2>
			<form className={style.form} onSubmit={handleOnSubmit}>
				<div className={style.formGroup}>
					<label htmlFor="name">Name</label>
					<input
						type="text"
						id="name"
						value={authorData.Name}
						onChange={handleInputChange}
						placeholder="full name"
					/>
				</div>
				<div className={style.formGroup}>
					<label htmlFor="dateofbirth">Date of Birth</label>
					<input
						type="text"
						id="dateofbirth"
						value={authorData.DateOfBirth}
						onChange={handleInputChange}
						placeholder="yyyy-mm-dd"
					/>
				</div>
				<div className={style.buttons}>
					<button type="reset" onClick={handleCancel}>
						cancel
					</button>
					<button type="submit">save</button>
				</div>
			</form>
		</div>
	);
};

export default AuthorForm;
