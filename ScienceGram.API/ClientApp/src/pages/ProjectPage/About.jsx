import styles from "./style.module.scss";

const About = () => {
	return (
		<div className={styles.about_wrapper}>
			<h1 className={styles.about_title}>
				Low progress math in a high performing system
			</h1>
			<p className={styles.about_desc}>
				Math anxiety negatively relates to math performance. This negative
				relationship may be exacerbated in low-progress math learners. However,
				there are limited studies on math anxiety among low progress learners in
				a paradoxically high performing education system like Singapore. To fill
				this research gap, this research analysed the anxiety profiles of 151
				students who were in the math learning support intervention program
				administered by the Ministry of Education, Singapore (MOE). We examined
				the complex relationship centred in math anxiety with relevant variables
				such as demographic characteristics, working memory and math
				performance. Limitations and future directions are discussed.
			</p>

			<p className={styles.authors}>
				A. Jamaludin, A. I. Jabir, F. J. Wang, A. L. Tan
			</p>

			<iframe
				title="Simulation"
				className={styles.iframe}
				src="https://phet.colorado.edu/sims/html/fourier-making-waves/latest/fourier-making-waves_all.html"
			></iframe>
		</div>
	);
};

export default About;
