from kivy.app import App
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.label import Label
from kivy.uix.textinput import TextInput
from kivy.uix.button import Button
from datetime import datetime, time

class MainWidget(BoxLayout):
    def __init__(self, **kwargs):
        super().__init__(orientation='vertical', **kwargs)

        self.entrada_receitas = TextInput(hint_text="RECEITA (ex: 13,3,4)", multiline=False)
        self.entrada_turno = TextInput(hint_text="TURNO", multiline=False)
        self.entrada_data = TextInput(hint_text="DATA (DD/MM/AAAA)", multiline=False)
        self.entrada_duracao = TextInput(hint_text="DURAÇÃO DO AQUECIMENTO (HH:MM)", multiline=False)
        self.resultado = Label(size_hint_y=None, height=100)

        self.botao_calcular = Button(text="Calcular")
        self.botao_calcular.bind(on_press=self.calcular_e_exibir_resultado)

        self.add_widget(self.entrada_receitas)
        self.add_widget(self.entrada_turno)
        self.add_widget(self.entrada_data)
        self.add_widget(self.entrada_duracao)
        self.add_widget(self.botao_calcular)
        self.add_widget(self.resultado)

    def calcular_e_exibir_resultado(self, instance):
        try:
            receitas = self.entrada_receitas.text
            lista_receitas = [int(x.strip()) for x in receitas.split(',')]
            turno = self.entrada_turno.text.upper()
            data_str = self.entrada_data.text
            data = datetime.strptime(data_str, '%d/%m/%Y').date()
            duracao_aquecimento_str = self.entrada_duracao.text
            duracao_aquecimento = datetime.strptime(duracao_aquecimento_str, "%H:%M").time()

            hora_padrao, tempo_padrao = self.obter_tempo_padrao(lista_receitas)
            diferenca_minutos = self.calcular_diferenca(duracao_aquecimento, hora_padrao)

            resultado = self.formatar_resultado(tempo_padrao, diferenca_minutos)
            self.resultado.text = resultado
        except Exception as e:
            self.resultado.text = f"Erro: {e}"

    def obter_tempo_padrao(self, lista_receitas):
        if all(receita in [13, 3, 4, 16, 22] for receita in lista_receitas):
            return time(13, 0), "13:00"
        elif all(receita in [12, 21] for receita in lista_receitas):
            return time(9, 0), "09:00"
        else:
            raise ValueError("Combinação de receitas não reconhecida.")

    def calcular_diferenca(self, duracao_aquecimento, hora_padrao):
        return (duracao_aquecimento.hour - hora_padrao.hour) * 60 + (duracao_aquecimento.minute - hora_padrao.minute)

    def formatar_resultado(self, tempo_padrao, diferenca_minutos):
        if diferenca_minutos == 0:
            return f"Tempo padrão: {tempo_padrao}\nAquecimento IGUAL ao tempo padrão."
        elif diferenca_minutos > 0:
            return f"Tempo padrão: {tempo_padrao}\nAquecimento ULTRAPASSOU em: {diferenca_minutos // 60} horas e {diferenca_minutos % 60} minutos."
        else:
            return f"Tempo padrão: {tempo_padrao}\nAquecimento FALTOU em: {abs(diferenca_minutos) // 60} horas e {abs(diferenca_minutos) % 60} minutos."

class MeuApp(App):
    def build(self):
        return MainWidget()

if __name__ == '__main__':
    MeuApp().run()