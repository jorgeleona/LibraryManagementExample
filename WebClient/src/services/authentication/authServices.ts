import Credentials from "./Credentials";
import ServiceBase from "../base/ServiceBase";

export const GetAuthToken = async (creds: Credentials): Promise<String> => {
	let authToken: String = "";

	try {
		const authResponse = await ServiceBase.AxiosInstance.post(
			"/auth/auth-token",
			creds
		);

		if (authResponse.status == 200) {
			authToken = authResponse.data;
		}
	} catch (error) {
		authToken = error.name;
	}
	return authToken;
};
