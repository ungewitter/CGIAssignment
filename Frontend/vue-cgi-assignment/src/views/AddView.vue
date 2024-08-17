<script setup lang="ts">
import TextInputVue from '../components/TextInput.vue'
import { ref } from 'vue'
import { useStore } from '../stores/businessCardStore'

const cardStore = useStore()

const firstName = ref('')
const lastName = ref('')
const phoneNumber = ref('')
const email = ref('')
const image = ref()
const resultMessage = ref('')

const handleImage = (event: any) => {
  image.value = event.target.files[0]
}

const addBusinessCard = async () => {
  const formValues = new FormData()
  formValues.append('firstName', firstName.value)
  formValues.append('lastName', lastName.value)
  formValues.append('phoneNumber', phoneNumber.value)
  formValues.append('email', email.value)
  formValues.append('imageFilePath', image.value)

  const response = await cardStore.addBusinessCard(formValues)
  if (response.id != null) {
    resultMessage.value = `${response.firstName} är tillagd`
  } else {
    resultMessage.value = 'Något gick snett'
  }
}
</script>

<template>
  <div class="about">
    <h1>Lägg till visitkort</h1>
    <div class="add-business-card-form">
      <TextInputVue label="Förnamn" v-model="firstName" :isRequired="true"></TextInputVue>
      <TextInputVue label="Efternamn" v-model="lastName" :isRequired="true"></TextInputVue>
      <TextInputVue label="Telefonnummer" v-model="phoneNumber" :isRequired="true"></TextInputVue>
      <TextInputVue label="Email" v-model="email" :isRequired="true"></TextInputVue>
      <input style="margin-top: 15px" type="file" @change="handleImage" :required="true" />
    </div>
    <button class="button" type="button" @click="addBusinessCard">Lägg till</button>
    <p>{{ resultMessage }}</p>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 50vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    flex-wrap: nowrap;
    justify-content: center;
  }
}

.add-business-card-form {
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
}

.button {
  margin-top: 15px;
  background-color: #04aa6d; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
}
</style>
