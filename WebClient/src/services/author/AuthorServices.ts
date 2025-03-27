import AuthorizedServiceBase from "services/base/AuthorizedServiceBase";
import { GetAuthToken } from "services/authentication/authServices";
import Credentials from "services/authentication/Credentials";
import Author from "./Author";
import { AxiosResponse, AxiosError } from "axios";

export const GetAuthors = async (creds: Credentials): Promise<Author[]> => {
	let authors: Author[] = [];
	try {
		const authToken: String = await GetAuthToken(creds);

		const authServiceBase: AuthorizedServiceBase = new AuthorizedServiceBase(
			authToken
		);

		const response: AxiosResponse =
			await authServiceBase.AxiosInstance.get("/api/authors");

		if (response.status == 200) {
			authors = response.data;
		}
	} catch (error: any) {
		const errorDetails = error as AxiosError;
		console.log(errorDetails.message);
	}

	return authors;
};
