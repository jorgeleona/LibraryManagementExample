import { useCallback, useEffect, useState, useContext } from "react";
import style from "./AuthorsTable.module.css";
import Author from "services/author/Author";
import { GetAuthors } from "services/author/AuthorServices";
import Credentials from "services/authentication/Credentials";
import FilterContext from "components/utils/Filter/FilterContext";

const creds: Credentials = { User: "xuser", Password: "#$$u53r??" };

const AuthorsTable = () => {
	const { filter } = useContext(FilterContext);

	const [authors, setAuthors] = useState<Author[]>([]);

	const fetchAuthors = useCallback(async () => {
		const authors = await GetAuthors(creds);
		setAuthors(authors);
	}, []);

	useEffect(() => {
		fetchAuthors();
	}, []);

	return (
		<div className={style.container}>
			<h2>Authors Table</h2>
			<span>filter is : {filter}</span>
			{authors.length < 0 ? (
				<span>No authors ...</span>
			) : (
				<>
					{authors.map((author: Author, index: number) => (
						<div key={"author" + index}>
							<p>
								{author.Name}
								{" - "}
								{new Date(author.DateOfBirth).toLocaleDateString()}
							</p>
						</div>
					))}
				</>
			)}
		</div>
	);
};

export default AuthorsTable;
