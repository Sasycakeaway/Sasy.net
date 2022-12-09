import svelte from 'rollup-plugin-svelte';
import resolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';
import livereload from 'rollup-plugin-livereload';
import { terser } from 'rollup-plugin-terser';
import sveltePreprocess from 'svelte-preprocess';
import typescript from '@rollup/plugin-typescript';
import css from 'rollup-plugin-css-only';
import dynamicImportVars from '@rollup/plugin-dynamic-import-vars';

const production = !process.env.ROLLUP_WATCH;

export default {
	input: 'src/main.ts',
	output: {
		sourcemap: true,
		format: 'iife',
		name: 'app',
		file: 'wwwroot/bundle.js'
	},
	plugins: [
		dynamicImportVars({
			include: ["components/statistiche.svelte","components/Contatti.svelte","components/Gallery.svelte","components/Decorati.svelte","components/Forbidden.svelte","components/Profile.svelte","components/ecommerce","components/Prodotti.svelte","components/Apebox.svelte","components/About.svelte","components/Ingredienti.svelte","components/why.svelte","components/SignIn.svelte","components/Index.svelte","components/Frolla_Cacao.svelte","components/Error404.svelte","components/Sacco_Di_Natale.svelte","components/SignUp.svelte",]
		}),
		css({ output: 'public/build/vendor.css' }),
		svelte({
			compilerOptions: {
				// enable run-time checks when not in production
				dev: !production,
				// we'll extract any component CSS out into
				// a separate file - better for performance
				css: css => {
					css.write('public/build/bundle.css');
				},
			},
			emitCss: false,
			preprocess: sveltePreprocess(),
		}),

		// If you have external dependencies installed from
		// npm, you'll most likely need these plugins. In
		// some cases you'll need additional configuration -
		// consult the documentation for details:
		// https://github.com/rollup/plugins/tree/master/packages/commonjs
		resolve({
			browser: true,
			dedupe: ['svelte']
		}),
		commonjs(),
		typescript({ 
			sourceMap: !production
		}),

		// Watch the `public` directory and refresh the
		// browser on changes when not in production
		!production && livereload('wwwroot'),

		// If we're building for production (npm run build
		// instead of npm run dev), minify
		production && terser()
	],
	watch: {
		clearScreen: false
	}
};