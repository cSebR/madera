<<<<<<< HEAD
	/* Data Hash: FFFFFFFFFFFFFFFF */
=======
	/* Data Hash: 7AA8C63C98E80A8B */
>>>>>>> 55936edeebf94802eba96bd06801bb289b772f9a
	.arch	armv8-a
	.file	"typemap.jm.inc"

	/* Mapping header */
	.section	.data.jm_typemap,"aw",@progbits
	.type	jm_typemap_header, @object
	.p2align	2
	.global	jm_typemap_header
jm_typemap_header:
	/* version */
	.word	1
	/* entry-count */
<<<<<<< HEAD
	.word	0
=======
	.word	1296
>>>>>>> 55936edeebf94802eba96bd06801bb289b772f9a
	/* entry-length */
	.word	0
	/* value-offset */
	.word	0
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
<<<<<<< HEAD
	.size	jm_typemap, 0
=======
	.size	jm_typemap, 339553
	.include	"typemap.jm.inc"
>>>>>>> 55936edeebf94802eba96bd06801bb289b772f9a
