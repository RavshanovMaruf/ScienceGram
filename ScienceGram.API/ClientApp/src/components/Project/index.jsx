import styles from "./style.module.scss";

const Project = () => {
	return (
		<div className={styles.project_wrapper}>
			<h1 className={styles.project_title}>
				Namioka spaces and strongly Baire spaces
			</h1>
			<p className={styles.project_summary}>
				A notion of strongly Baire space is introduced. Its definition is a
				<br />
				transfinite development of some equivalent reformulation of the Baire
				space
				<br />
				definition. It is shown that every strongly Baire space is a Namioka
				space and
				<br />
				every $\\beta-\\sigma$-unfavorable space is a strongly Baire space.
			</p>
			<p className={styles.project_author}>V. V. Mykhaylyuk</p>
			<p className={styles.project_journal}>
				Mat. Studii. 26, N1 (2006), 55-64
			</p>
		</div>
	);
};

export default Project;

// {
//   "entries": [
//     {
//       "id": "http://arxiv.org/abs/1601.05884v1",
//       "published": "2016-01-22T06:23:23Z",
//       "title": "Namioka spaces and strongly Baire spaces",
//       "summary": "  A notion of strongly Baire space is introduced. Its definition is a\ntransfinite development of some equivalent reformulation of the Baire space\ndefinition. It is shown that every strongly Baire space is a Namioka space and\nevery $\\beta-\\sigma$-unfavorable space is a strongly Baire space.\n",
//       "authors": [
//         {
//           "name": "V. V. Mykhaylyuk",
//           "affiliation": null
//         }
//       ],
//       "journalRef": "Mat. Studii. 26, N1 (2006), 55-64",
//     }
//   ]
// }
