<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const login = ref('')
const password = ref('')

async function register() {
if (
    !login.value.trim() ||
    !password.value.trim()
) {
    alert(
        'Введите логин и пароль'
    )
    return
}
    const response = await fetch(
        'http://localhost:5123/register',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                login: login.value,
                password: password.value
            })
        }
    )

    if (response.ok) {

        alert('Регистрация выполнена')

        router.push('/login')
    }
    else {
        alert('Пользователь уже существует')
    }
}
</script>

<template>
    <div class="p-5">

        <h1 class="text-2xl mb-4">
            Регистрация
        </h1>

        <input
            v-model="login"
            placeholder="Логин"
            class="border p-2 mb-3 block"
        >

        <input
            v-model="password"
            type="password"
            placeholder="Пароль"
            class="border p-2 mb-3 block"
        >

        <button
            @click="register"
            class="border px-4 py-2"
        >
            Зарегистрироваться
        </button>

    </div>
</template>