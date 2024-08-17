<script setup lang="ts">
import TextInputVue from '../components/TextInput.vue'
import { ref } from 'vue'
import { useStore } from '../stores/businessCardStore'

const cardStore = useStore()

const cardId = ref('')
const resultMessage = ref('')

const deleteCard = async () => {
  const response = await cardStore.removeBusinessCard(cardId.value)
  if (response.id != null) {
    resultMessage.value = `${response.firstName} är borttagen`
  } else {
    resultMessage.value = 'Något gick snett'
  }
}
</script>

<template>
  <div class="about">
    <h1>Ta bort ett visitkort</h1>
    <div class="delete-business-card-form">
      <TextInputVue label="Visitkort-id" v-model="cardId" :isRequired="true"></TextInputVue>
    </div>
    <button class="button" type="button" @click="deleteCard">Ta bort</button>
    <p>{{ resultMessage }}</p>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}

.delete-business-card-form {
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
}

.button {
  margin-top: 15px;
  background-color: #04aa6d;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
}
</style>
