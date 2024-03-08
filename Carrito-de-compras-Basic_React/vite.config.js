import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// https://vitejs.dev/config/
export default defineConfig({
	server: {
		port: 3000,
	},
	plugins: [react()],
	define: {
		'import.meta.env': {
			VITE_API_KEY: JSON.stringify(process.env.VITE_API_KEY),
			// Agrega aquí otras variables de entorno necesarias
		}
	}
});