import * as contentful from 'contentful';

let client: contentful.ContentfulClientApi | null = null;

try {
	client = contentful.createClient({
		accessToken: 'TAx_dHq6aZrL9Smzjvsg61a79UYKlDP8fAvyuZEbKbM',
		space: '2yqbgg61blr3'
	});
} catch (error) {
	console.log('Errore durante il collegamento con il CMS');
	console.error(error);
	client = null;
}

export default client;
