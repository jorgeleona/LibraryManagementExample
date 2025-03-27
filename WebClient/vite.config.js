import path from "path";
import { defineConfig } from "vite";
import tsconfigPaths from "vite-tsconfig-paths";

import react from "@vitejs/plugin-react";

// https://vite.dev/config/
export default defineConfig({
	plugins: [react(), tsconfigPaths()],
	resolve: {
		alias: {
			// eslint-disable-next-line no-undef
			"@": path.resolve(__dirname, "./src")
		}
	}
});
