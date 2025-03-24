import { useCallback, useEffect, useState } from "react";
import style from "./AuthorsTable.module.css";
import Author from "services/author/Author";
import Credentials from "services/authencation/Credentials";
import { GetAuthors } from "services/author/services";

const creds: Credentials = { User: "xuser", Password: "#$$u53r??" };

const AuthorsTable = () => {
	const [authors, setAuthors] = useState<Author[]>([]);

	const fetchAuthors = useCallback(async (): Promise<Author[]> => {
		return await GetAuthors(creds);
	}, []);

	useEffect(() => {
		fetchAuthors().then((authors) => setAuthors(authors));
	}, []);

	return (
		<div className={style.container}>
			<h2>Authors Table</h2>
			{authors.length > 0 ? (
				<span>No authors ...</span>
			) : (
				<>
					{authors.map((author: Author) => (
						<>
							<span>
								{author.Name} , born on {author.DateOfBirth.toDateString()}
							</span>
						</>
					))}
				</>
			)}
		</div>
	);
};

export default AuthorsTable;
