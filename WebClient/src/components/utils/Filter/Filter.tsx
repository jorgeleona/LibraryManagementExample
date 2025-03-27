import React, { useCallback, useContext } from "react";
import style from "./Filter.module.css";
import FilterContext from "./FilterContext";

export interface FilterProps {
	placeholder: string;
}

const Filter = ({ placeholder }: FilterProps) => {
	const { filter, setFilter } = useContext(FilterContext);

	const debounce = (cb: any, delay: number = 1000) => {
		let timeout: any;
		return (...args: any[]) => {
			clearTimeout(timeout);
			timeout = setTimeout(() => {
				cb(...args);
			}, delay);
		};
	};

	const updateFilter = debounce((filter: string) => {
		setFilter(filter);
	}, 500);

	const handleFilterChange = useCallback(
		(event: React.ChangeEvent<HTMLInputElement>) => {
			const { value } = event.target;
			updateFilter(value);
		},
		[]
	);

	return (
		<div className={style.container}>
			<input
				type="text"
				placeholder={placeholder}
				onChange={handleFilterChange}
			/>
			<span>{filter}</span>
		</div>
	);
};

export default Filter;
