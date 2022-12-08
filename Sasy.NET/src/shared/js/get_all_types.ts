import client from './contentfulClient';

export async function get_all_types(): Promise<Array<DropdownProd>> {
	const all_types: Array<DropdownProd> = [];

	const raw_types = await client?.getEntries({
		content_type: 'type'
	});

	raw_types?.items.forEach((element) => {
		const type = element.fields.type;
		if (all_types.filter((e) => e.type === type).length == 0) {
			all_types.push({
				type: type,
				name: element.fields.typeMenu,
				description: element.fields.subTitle,
				image: element.fields.coverAll.fields.file.url.replace("//", "https://")
			});
		}
	});
	return all_types;
}

export async function get_page_header_type(type: string) {
	let header: Header_Info = {
		title: '',
		subtitle: '',
		image: ''
	};
	const raw_types = await client?.getEntries({
		content_type: 'type'
	});

	raw_types?.items.forEach((element) => {
		if (element.fields.type == type) {
			header = {
				title: element.fields.title,
				subtitle: element.fields.subTitle,
				image: element.fields.cover.fields.file.url.replace('//', 'https://')
			};
		}
	});
	return header;
}
