import React, { useState } from "react";
import style from "./CategoryForm.module.css";
import Category from "services/category/Category";

const authUrl = "http://localhost:5172/auth/auth-token";
const saveCategoryUrl = "http://localhost:5172/api/categories";

const apiKey =
	"XmpV6v6G0YCc05dasg5XJKf8HL6k6BcteiFa6gh4HGckgBw01IiC3OPPNpl9myjlftk8gQ3rCB69MAoZ47h3KdLjMIeEumCcynKqyp48CtHkcVNQmMfqLd7s9795qnLccbrVNj7snPPipNQbZaQVwDYtkd2sBQ8UqrNxXfyem1wQtpIdYVqvVIzfrcrvDE73bcYNcdy3rDtLYvRQrnPdfeut3Z8lgFwc4MCGgZORVsOWCQfArszpQe5qfdSOWUAe";
const creds = { User: "xuser", Password: "#$$u53r??" };

const defaultCategory: Category = {
	Name: ""
};

const CategoryForm = () => {
	const [categoryData, setCategoryData] = useState<Category>(defaultCategory);

	const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		const { id, value } = event.target;
		setCategoryData((prev) => ({ ...prev, [id]: value }));
	};

	const handleOnSubmit = async (event: React.FormEvent) => {
		event.preventDefault();
		console.log("to send  :", categoryData);

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
			const payload = JSON.stringify(categoryData);

			const saveResponse = await fetch(saveCategoryUrl, {
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
				setCategoryData(defaultCategory);
			}
		} else {
			console.log("auth failed");
		}
	};

	const handleCancel = () => {
		setCategoryData(defaultCategory);
	};

	return (
		<div className={style.container}>
			<h2>Add Category</h2>
			<form className={style.form} onSubmit={handleOnSubmit}>
				<div className={style.formGroup}>
					<label htmlFor="name">Name</label>
					<input
						type="text"
						id="name"
						value={categoryData.Name}
						onChange={handleInputChange}
						placeholder="full name"
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

export default CategoryForm;
