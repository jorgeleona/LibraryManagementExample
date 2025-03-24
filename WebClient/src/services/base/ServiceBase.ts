import axios from "axios";

export default class ServiceBase {
	private static apiKey =
		"XmpV6v6G0YCc05dasg5XJKf8HL6k6BcteiFa6gh4HGckgBw01IiC3OPPNpl9myjlftk8gQ3rCB69MAoZ47h3KdLjMIeEumCcynKqyp48CtHkcVNQmMfqLd7s9795qnLccbrVNj7snPPipNQbZaQVwDYtkd2sBQ8UqrNxXfyem1wQtpIdYVqvVIzfrcrvDE73bcYNcdy3rDtLYvRQrnPdfeut3Z8lgFwc4MCGgZORVsOWCQfArszpQe5qfdSOWUAe";

	private static apiBaseConfig = {
		baseURL: "http://localhost:5172",
		allowAbsoluteUrls: false,
		headers: {
			"Access-Control-Allow-Origin": "http://localhost:5173",
			Accept: "application/json",
			"Content-Type": "application/json",
			"x-api-key": ServiceBase.apiKey
		}
	};

	static AxiosInstance = axios.create(ServiceBase.apiBaseConfig);
}
