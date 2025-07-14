from fastapi import FastAPI
from pydantic import BaseModel
from transformers import pipeline

app = FastAPI()

generator = pipeline("text2text-generation", model="google/flan-t5-base")

class Produto(BaseModel):
    nome: str
    categoria: str 

@app.post("/gerar-descricao")
def gerar_descricao(produto: Produto):
    prompt = f"Write a product description for a product named '{produto.nome}' in the category '{produto.categoria}'. Include as many technical details as possible."
    resultado = generator(
        prompt,
        max_length=250,         
        do_sample=True,         
        top_p=0.9,              
        temperature=0.8         
    )[0]['generated_text']
    return { "descricao": resultado }
