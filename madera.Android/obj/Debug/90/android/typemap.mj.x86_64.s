<<<<<<< HEAD
	/* Data Hash: FFFFFFFFFFFFFFFF */
=======
	/* Data Hash: FCE94E381DB1AD35 */
>>>>>>> 55936edeebf94802eba96bd06801bb289b772f9a
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
<<<<<<< HEAD
	.long	0
=======
	.long	1441
>>>>>>> 55936edeebf94802eba96bd06801bb289b772f9a
	/* entry-length */
	.long	0
	/* value-offset */
	.long	0
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
<<<<<<< HEAD
	.size	mj_typemap, 0
=======
	.size	mj_typemap, 377543
	.include	"typemap.mj.inc"
>>>>>>> 55936edeebf94802eba96bd06801bb289b772f9a
