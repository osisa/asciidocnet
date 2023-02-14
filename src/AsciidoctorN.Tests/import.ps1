#pandoc --from=docx --to=asciidoc --wrap=none --atx-headers --extract-media=extracted-media c:\asciidoctest\ti1.docx > c:\asciidoctest\to1.adoc

#pandoc --from=docx --to=asciidoc --wrap=none --atx-headers --extract-media=extracted-media c:\asciidoctest\Finanzreglement.docx > c:\asciidoctest\Finanzreglement.adoc


#pandoc c:\asciidoctest\ti1.docx -f docx -t asciidoc --wrap=none --markdown-headings=atx --extract-media=extracted-media  -o c:\asciidoctest\to2.adoc#

#pandoc c:\asciidoctest\finanzreglement.docx -f docx -t asciidoc --wrap=none --markdown-headings=atx --extract-media=extracted-media  -o c:\asciidoctest\finanzreglement2.adoc


#pandoc c:\asciidoctest\statuten.adocx -f adoc -t docx --wrap=none --markdown-headings=atx --extract-media=extracted-media  -o c:\asciidoctest\statuten.docx

#https://rmoff.net/2020/04/16/converting-from-asciidoc-to-google-docs-and-ms-word/
#asciidoctor --backend docbook --out-file c:\asciidoctest\statutenMitte2.xml c:\asciidoctest\statutenMitte2.adoc
#pandoc --from docbook --to docx --output c:\asciidoctest\statutenMitte2.docx --reference-doc c:\asciidoctest\MitteReference.docx c:\asciidoctest\statutenMitte2.xml


asciidoctor --backend docbook --out-file c:\asciidoctest\Finanzreglement3.xml c:\asciidoctest\Finanzreglement3.adoc
pandoc --from docbook --to docx --output c:\asciidoctest\Finanzreglement3.docx --reference-doc c:\asciidoctest\MitteReference.docx c:\asciidoctest\Finanzreglement3.xml

#pandoc --from docbook --to pdf --output c:\asciidoctest\statutenMitte2.pdf --pdf-engine wkhtmltopdf c:\asciidoctest\statutenMitte2.xml
