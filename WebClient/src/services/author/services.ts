import ServiceBase from "../base/ServiceBase";
import AuthorizedServiceBase from "../base/AuthorizedServiceBase";
import { GetAuthToken } from "../authencation/services";
import Credentials from "../authencation/Credentials";
import Author from "./Author";
import { AxiosResponse } from "axios";

export const GetAuthors = async (creds: Credentials): Promise<Author[]> => {
	let authors: Author[] = [];
	try {
		const authToken: String = await GetAuthToken(creds);

		const authServiceBase: AuthorizedServiceBase = new AuthorizedServiceBase(
			authToken
		);

		const response: AxiosResponse =
			await authServiceBase.AxiosInstance.get("/authors");

		if (response.status == 200) {
			authors = response.data;
		}
	} catch (error) {
		console.log(error.name);
	}

	return authors;
};
