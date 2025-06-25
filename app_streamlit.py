import streamlit as st
from datetime import datetime, time

def obter_tempo_padrao(lista_receitas):
    if all(receita in [13, 3, 4, 16, 22] for receita in lista_receitas):
        return time(13, 0), "13:00"
    elif all(receita in [12, 21] for receita in lista_receitas):
        return time(9, 0), "09:00"
    else:
        raise ValueError("Combinação de receitas não reconhecida.")

def calcular_diferenca(duracao_aquecimento, hora_padrao):
    return (duracao_aquecimento.hour - hora_padrao.hour) * 60 + (duracao_aquecimento.minute - hora_padrao.minute)

def formatar_resultado(tempo_padrao, diferenca_minutos):
    if diferenca_minutos == 0:
        return f"Tempo padrão: {tempo_padrao}\nAquecimento IGUAL ao tempo padrão."
    elif diferenca_minutos > 0:
        return f"Tempo padrão: {tempo_padrao}\nAquecimento ULTRAPASSOU em: {diferenca_minutos // 60} horas e {diferenca_minutos % 60} minutos."
    else:
        return f"Tempo padrão: {tempo_padrao}\nAquecimento FALTOU em: {abs(diferenca_minutos) // 60} horas e {abs(diferenca_minutos) % 60} minutos."

st.title("Acompanhamento de Aquecimento RC4")

receitas = st.text_input("Receita (ex: 13,3,4)")
turno = st.text_input("Turno (Manhã, Tarde, Noite)")
data_str = st.text_input("Data (DD/MM/AAAA)")
duracao_aquecimento_str = st.text_input("Duração do Aquecimento (HH:MM)")

if st.button("Calcular"):
    try:
        lista_receitas = [int(x.strip()) for x in receitas.split(',')]
        turno_upper = turno.upper()
        data = datetime.strptime(data_str, '%d/%m/%Y').date()
        duracao_aquecimento = datetime.strptime(duracao_aquecimento_str, "%H:%M").time()

        resumo_texto = (
            f"Receita: {receitas}\n"
            f"Turno: {turno_upper}\n"
            f"Data: {data_str}\n"
            f"Duração Aquecimento: {duracao_aquecimento_str}\n"
        )

        hora_padrao, tempo_padrao = obter_tempo_padrao(lista_receitas)
        diferenca_minutos = calcular_diferenca(duracao_aquecimento, hora_padrao)
        resultado = formatar_resultado(tempo_padrao, diferenca_minutos)

        st.text_area("Resumo + Resultado", resumo_texto + "\n" + resultado, height=220)
    except Exception as e:
        st.error(f"Erro: {e}")
