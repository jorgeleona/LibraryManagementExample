import FilterAuthorsContext from "../components/utils/Filter/FilterContext";
import Filter from "components/utils/Filter/Filter";
import AuthorForm from "components/authors/AuthorForm/AuthorForm";
import AuthorsTable from "components/authors/AuthorsTable/AuthorsTable";
import { useState } from "react";

const Authors = () => {
	const [filter, setFilter] = useState<string>("");
	const value = { filter, setFilter };
	return (
		<>
			<AuthorForm />
			<FilterAuthorsContext.Provider value={value}>
				<Filter placeholder="filter authors by name" />
				<AuthorsTable />
			</FilterAuthorsContext.Provider>
		</>
	);
};

export default Authors;
