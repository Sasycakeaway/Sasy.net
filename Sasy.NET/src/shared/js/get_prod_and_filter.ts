import client from './contentfulClient';
import { documentToHtmlString } from '@contentful/rich-text-html-renderer';
import { BLOCKS, MARKS } from '@contentful/rich-text-types';

export async function get_prod_and_filter(prod: string): Promise<Array<Prodotto>> {
	const filtered_prod: Array<Prodotto> = [];

	const raw_prod = await client?.getEntries({
		content_type: 'prodotti'
	});

	raw_prod?.items.forEach((element) => {
		const type = element.fields.type;
		try {
			if (type == prod) {
				filtered_prod.push({
					nome: element.fields.prodottoName,
					shortDescription: element.fields.shortDescription,
					description: element.fields.description.content[0].content[0].value,
					image: element.fields.headerPhoto.fields.file.url.replace('//', 'https://'),
					citazione: element.fields.citazione,
					is_single_page: false,
					gallery: [],
					buyable: element.fields.buyable,
					price: element.fields.price,
					buyPhrase: element.fields.buyPhrase
				});
			}
		} catch (error) {
			try {
				filtered_prod.push({
					nome: element.fields.prodottoName,
					shortDescription: element.fields.shortDescription,
					description: element.fields.description.content[0].content[0].value,
					image: '',
					citazione: element.fields.citazione,
					is_single_page: false,
					gallery: [],
					buyable: element.fields.buyable,
					price: element.fields.price,
					buyPhrase: element.fields.buyPhrase
				});
			} catch (error) {
				console.error(error);
			}
		}
	});

	if (filtered_prod.length == 0) {
		const single_prod: Array<Prodotto> = [];
		const raw_prod = await client?.getEntries({
			content_type: 'singleProductPage'
		});
		const options = {
			// Contentful HTML options, need to add class
			renderNode: {
				[BLOCKS.PARAGRAPH]: (node: { content: any }, next: (arg0: any) => any) =>
					`<p class="para">${next(node.content)}</p class="det">`
			}
		};
		raw_prod?.items.forEach((element) => {
			const type = element.fields.type;
			if (type == prod) {
				const images: Array<string> = [];
				element.fields.gallery.forEach((image) => {
					images.push(image.fields.file.url.replace('//', 'https://'));
				});
				single_prod.push({
					nome: element.fields.subtitle,
					shortDescription: '',
					description: documentToHtmlString(element.fields.description, options),
					image: '',
					citazione: '',
					is_single_page: true,
					gallery: images,
					buyable: element.fields.buyable,
					price: element.fields.price,
					buyPhrase: element.fields.buyPhrase
				});
			}
		});
		return single_prod;
	}

	return filtered_prod;
}
