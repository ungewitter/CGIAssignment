<script setup lang="ts">
import TextInputVue from '../components/TextInput.vue'
import { ref } from 'vue'
import { useStore } from '../stores/businessCardStore'
import { config } from '@/config'

const cardStore = useStore()

const cardId = ref('')
const firstName = ref('')
const lastName = ref('')
const phoneNumber = ref('')
const email = ref('')
const image = ref()
const imageFilePath = ref('')
const resultMessage = ref('')

const handleImage = (event: any) => {
  image.value = event.target.files[0]
}

const getBusinessCard = async () => {
  const response = await cardStore.getBusinessCardById(cardId.value)
  firstName.value = response.firstName
  lastName.value = response.lastName
  email.value = response.email
  phoneNumber.value = response.phoneNumber
  imageFilePath.value = response.imageFilePath
}

const updateBusinessCard = async () => {
  const formValues = new FormData()
  formValues.append('firstName', firstName.value)
  formValues.append('lastName', lastName.value)
  formValues.append('phoneNumber', phoneNumber.value)
  formValues.append('email', email.value)
  formValues.append('imageFilePath', image.value)

  const response = await cardStore.updateBusinessCard(cardId.value, formValues)
  if (response.id != null) {
    resultMessage.value = `${response.firstName} har uppdaterat kort`
  } else {
    resultMessage.value = 'Något gick snett'
  }
}
</script>

<template>
  <div class="about">
    <h1>Uppdatera visitkort</h1>
    <div class="add-business-card-form">
      <TextInputVue label="Visitkort-id" v-model="cardId" :isRequired="true"></TextInputVue>
      <TextInputVue label="Förnamn" v-model="firstName" :isRequired="false"></TextInputVue>
      <TextInputVue label="Efternamn" v-model="lastName" :isRequired="false"></TextInputVue>
      <TextInputVue label="Telefonnummer" v-model="phoneNumber" :isRequired="false"></TextInputVue>
      <TextInputVue label="Email" v-model="email" :isRequired="false"></TextInputVue>
      <div>
        <img v-if="imageFilePath" class="update-image" :src="`${config.apiUrl}/${imageFilePath}`" />
        <input style="margin-top: 15px" type="file" @change="handleImage" :required="false" />
      </div>
    </div>
    <button class="button" type="button" @click="getBusinessCard">Hämta uppgifter via ID</button>
    <button class="button" type="button" @click="updateBusinessCard">Uppdatera visitkort</button>
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

.update-image {
  width: 25%;
  max-height: 100%;
}
</style>
