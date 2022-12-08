import client from './contentfulClient';

export async function gallery() {
	const raw_types = await client?.getEntries({
		content_type: 'gallery'
	});
	return raw_types;
}
