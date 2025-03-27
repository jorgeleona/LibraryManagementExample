import { test, expect } from "@jest/globals";
import { GetAuthToken } from "./authServices";
import Credentials from "./Credentials";

test("Connected Test (Local) - GetAuthToken - Success", async () => {
	const creds: Credentials = { User: "xuser", Password: "#$$u53r??" };
	const authToken = await GetAuthToken(creds);

	expect(authToken).not.toBe(null);
});
