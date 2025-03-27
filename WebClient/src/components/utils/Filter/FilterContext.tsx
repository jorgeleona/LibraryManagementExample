import { createContext, Dispatch, SetStateAction } from "react";

export interface FilterContextInterface {
	filter: string;
	setFilter: Dispatch<SetStateAction<string>>;
}

const FilterContext = createContext<FilterContextInterface>({
	filter: "",
	setFilter: () => {}
});

export default FilterContext;
