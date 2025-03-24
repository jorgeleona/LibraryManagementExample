import axios, { AxiosInstance, CreateAxiosDefaults } from "axios";

export default class AuthorizedServiceBase {
	private _authToken: String;
	public AxiosInstance: AxiosInstance;

	constructor(authToken: String) {
		this._authToken = authToken;

		const apiBaseConfig: CreateAxiosDefaults = {
			baseURL: "http://localhost:5172",
			allowAbsoluteUrls: false,
			headers: {
				"Access-Control-Allow-Origin": "http://localhost:5173",
				"Access-Control-Allow-Credentials": "true",
				Accept: "application/json",
				"Content-Type": "application/json",
				"x-api-key": AuthorizedServiceBase.apiKey,
				Authorization: "Bearer " + this._authToken
			}
		};

		this.AxiosInstance = axios.create(apiBaseConfig);
	}

	private static apiKey =
		"XmpV6v6G0YCc05dasg5XJKf8HL6k6BcteiFa6gh4HGckgBw01IiC3OPPNpl9myjlftk8gQ3rCB69MAoZ47h3KdLjMIeEumCcynKqyp48CtHkcVNQmMfqLd7s9795qnLccbrVNj7snPPipNQbZaQVwDYtkd2sBQ8UqrNxXfyem1wQtpIdYVqvVIzfrcrvDE73bcYNcdy3rDtLYvRQrnPdfeut3Z8lgFwc4MCGgZORVsOWCQfArszpQe5qfdSOWUAe";
}
