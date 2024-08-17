<script setup lang="ts">
defineProps<{
  cardId: string
  firstName: string
  lastName: string
  phoneNumber: string
  email: string
  imageUrl: string
}>()
</script>

<template>
  <div class="business-card-container">
    <div class="image-container">
      <img class="card-image" :src="imageUrl" />
    </div>
    <div class="contact-info-container">
      <p>Visitkort-id: {{ cardId }}</p>
      <p>{{ firstName }}</p>
      <p>{{ lastName }}</p>
      <p>{{ phoneNumber }}</p>
      <p>{{ email }}</p>
    </div>
  </div>
</template>

<style>
.business-card-container {
  width: 70%;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  border: 1px solid;
  border-radius: 8px;
  border-color: antiquewhite;
  flex-direction: row;
}

.image-container {
  max-width: 50%;
  padding: 5px 10px 5px 10px;
}

.card-image {
  width: 100%;
  max-height: 100%;
}

.contact-info-container {
  width: 50%;
  display: flex;
  flex-wrap: nowrap;
  flex-direction: column;
  padding: 5px 0 5px 0;
}
</style>
