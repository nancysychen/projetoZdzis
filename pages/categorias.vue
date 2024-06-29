<template>
  <div>

    <!-- <v-card class="mx-auto" max-width="400" -->

    <v-toolbar color="orange-lighten-1" dark>
      <!-- <v-app-bar-nav-icon></v-app-bar-nav-icon> -->

      <v-toolbar-title> Cadastro de Categorias</v-toolbar-title>


    </v-toolbar>

    <!-- <v-sheet class="mx-auto" width="700"> -->

    <v-form ref="form">
      <v-text-field v-model="categoria.nome" :min="5" :rules="nomeRules" label="Categoria" required></v-text-field>

      <v-text-field v-model="categoria.descricao" label="Descrição"></v-text-field>



      <div class="d-flex flex-column">
        <v-btn class="mr-4" color="success" block @click="submit">
          Salvar
        </v-btn>


      </div>
    </v-form>



    <template>


      <pre>
            {{ categoria }}
       </pre>


      <!-- </v-sheet> -->
    </template>

    <v-table class="spaced-table">
      <thead>
        <tr>
          <th class="text-left" style="padding: 10px;">
            Categoria
          </th>
          <th class="text-right" style="padding: 10px;">
            Descrição
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in categorias" :key="item.nome">
          <td style="padding: 10px;">{{ item.nome }}</td>
          <td style="padding: 10px;">{{ item.descricao }}</td>
        </tr>
      </tbody>
    </v-table>


  </div>
</template>

<script>
export default {
  data: () => ({

    headers: [
      {
        text: 'Categoria',
        align: 'start',
        sortable: false,
        value: 'nome'
      },
      {
        text: 'Descrição', value: 'descricao'
      },

    ],

    categorias: [{
      nome: 'Categoria 1',
      descricao: 'descricao categoria 1',
    }],


    valid: true,

    categoria: {
      nome: '',
      descricao: '',

    },
    nomeRules: [
      v => !!v || 'Nome é obrigatório',
      v => (v && v.length > 5) || 'Nome deve ser de pelo menos 5 caracteres',
    ],
  }),

  methods: {
    async submit() {

      // debugger;

      try {
        let response = await this.$axios({
          method: 'POST',
          url: 'http://localhost:5008/Categoria',
          data: this.categoria
        });

        // debugger;

        let responseGet = await this.$axios({
          method: 'GET',
          url: 'http://localhost:5008/Categoria',

        });

        // debugger;
        this.categorias = responseGet.data;

      } catch { }
    },

  },
}


</script>

<style lang="scss" scoped></style>